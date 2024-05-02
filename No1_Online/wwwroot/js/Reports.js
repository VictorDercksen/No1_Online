document.addEventListener("DOMContentLoaded", function () {
    document.getElementById('submitIncomePerVehicle').addEventListener('click', function (e) {
        e.preventDefault(); // Prevent the default form submission behavior

        // Retrieve the company value from the input
        var transporter = document.querySelector('#incomePerVehicleForm input[name="transporter"]').value;
        var startDate = document.querySelector('#incomePerVehicleForm input[name="startDateIncomePerVehicle"]').value;
        var endDate = document.querySelector('#incomePerVehicleForm input[name="endDateIncomePerVehicle"]').value;
        // Construct the URL for the AJAX request
        var url = '/Reports/IncomePerVehicle' + '?transporter=' + encodeURIComponent(transporter) + '&startDate=' + encodeURIComponent(startDate) + '&endDate=' + encodeURIComponent(endDate);
        var title = "Income Per Vehicle"; // The title for the tab

        // Call the predefined function
        loadPartialViewIntoTab(url, title);
    });
});