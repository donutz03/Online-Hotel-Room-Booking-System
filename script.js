// script.js

document.addEventListener('DOMContentLoaded', function () {
    // Code to execute when the DOM is fully loaded

    // Retrieve the form element
    var bookingForm = document.getElementById('booking-form');

    // Attach an event listener to the form submission
    bookingForm.addEventListener('submit', function (event) {
        event.preventDefault(); // Prevent form submission

        // Retrieve the form input values
        var checkInDate = document.getElementById('check-in-date').value;
        var checkOutDate = document.getElementById('check-out-date').value;

        // Perform validation on the input values
        if (checkInDate === '' || checkOutDate === '') {
            alert('Please select both check-in and check-out dates.');
            return;
        }

        // Perform further processing or submission of the booking form
        // ...

        // Reset the form
        bookingForm.reset();
    });
});
