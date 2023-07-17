using Application.Interfaces;
using Application.Models.Payment;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SWP_template.Models;
using System.Data.SqlTypes;

namespace SWP_template.Controllers;

public class PaymentController : Controller
{
    Swp1Context context = new Swp1Context();
    private readonly IVNPayService _vnPayService;

    public PaymentController(IVNPayService vnPayService)
    {
        _vnPayService = vnPayService;
    }

    [HttpPost]
    public ActionResult Checkout(Order model)
    {   //cần thay đổi khi có id của room//
        var room = context.Rooms.First(s => s.RoomId == model.RoomId);
        var account = HttpContext.Session.GetString("ID");

        if (string.IsNullOrEmpty(account))
        {
            return Redirect("/Login");
        }
        TimeSpan stayTime = model.CheckOut - model.CheckIn;
        int time = stayTime.Days;
        model.AccountId = account;
        model.RoomName = room.RoomName;
        model.RoomType = room.RoomName;
        model.TotalPrice= model.RoomQualtity * decimal.Parse(room.RoomPrice) * time;

        if (model.PayMethod.ToLower().Equals("vnpay"))
        {
            model.PaymentStatus = "Paid";
            var jsonString = JsonConvert.SerializeObject(model);
            HttpContext.Session.SetString("OrderSession", jsonString);
            var redirectTo = _vnPayService.CreatePayment(new PaymentInfoModel()
            {
                PaymentCode = "VNPay",
                TotalAmount = model.RoomQualtity * double.Parse(room.RoomPrice) * time
            }, HttpContext);

            return Redirect(redirectTo.Uri);
        }

        model.PaymentStatus = "Pending";
        context.Orders.Add(model);
        context.SaveChanges();

        return Redirect("/Home?success=true&paymentMethod=Cash");
    }

    [HttpGet]
    public IActionResult PaymentCallback()
    {
        var queryCollection = Request.Query;

        if (queryCollection?.Count == 0)
            return Redirect("/Home?success=false");

        if (queryCollection?.Count == 0)
            return Redirect("/Home?success=false");

        var paymentMethod = queryCollection.FirstOrDefault(t => t.Key.Contains("payment_method")).Value
            .ToString().ToLower();

        switch (paymentMethod)
        {
            case "vnpay":
                var vnPayResponse = _vnPayService.PaymentExecute(Request.Query);

                if (vnPayResponse.Success)
                {
                    var jsonString = HttpContext.Session.GetString("OrderSession");
                    var order = JsonConvert.DeserializeObject<Order>(jsonString ?? "{}");
                    if (!string.IsNullOrEmpty(order?.AccountId))
                    {
                        context.Orders.Add(order);
                        context.SaveChanges();
                        HttpContext.Session.SetString("OrderSession", "");
                    }
                }

                return Redirect(!vnPayResponse.Success
                    ? "/Home?success=false&paymentMethod=VnPay"
                    : "/Home?success=true&paymentMethod=VnPay");
            default:
                return Redirect("/");
        }
    }
}