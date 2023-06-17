// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showEditModal() {
    var firstName = document.getElementById('firstName').value;
    var lastName = document.getElementById('lastName').value;
    var email = document.getElementById('email').value;
    var phone = document.getElementById('phone').value;
    var country = document.getElementById('country').value;
    var arrivalDate = document.getElementById('arrivalDate').value;
    var departureDate = document.getElementById('departureDate').value;
    var quatityRoom = document.getElementById('quatityRoom').value;
    var bed = document.getElementById('bed').value;
    var adults = document.getElementById('adults').value;
    var childs = document.getElementById('childs').value;
    var payMethod = document.getElementById('payMethod').value;


    // Truyền giá trị vào modal thông qua các biến hoặc thuộc tính của JavaScript
    document.getElementById('editFirstName').value = firstName;
    document.getElementById('editLastName').value = lastName;
    document.getElementById('editEmail').value = email;
    document.getElementById('editPhone').value = phone;
    document.getElementById('editCountry').value = country;
    document.getElementById('editArrivalDate').value = arrivalDate;
    document.getElementById('editDepartureDate').value = departureDate;
    document.getElementById('editAuatityRoom').value = quatityRoom;
    document.getElementById('editBed').value = bed;
    document.getElementById('editAdults').value = adults;
    document.getElementById('editChilds').value = childs;
    document.getElementById('editPayMethod').value = payMethod;

    $('#editModal').modal('show'); // Hiển thị modal khi nhấp vào nút "Edit"
}