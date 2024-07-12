﻿document.addEventListener("DOMContentLoaded", function () {
    document.getElementById('submitIncomePerVehicle').addEventListener('click', function (e) {
        e.preventDefault(); // Prevent the default form submission behavior

        // Retrieve the company value from the input
        var transporter = document.querySelector('#incomePerVehicleForm input[name="transporter"]').value;
        var startDate = document.querySelector('#incomePerVehicleForm input[name="startDateIncomePerVehicle"]').value;
        var endDate = document.querySelector('#incomePerVehicleForm input[name="endDateIncomePerVehicle"]').value;
        // Construct the URL for the AJAX request
        var url = '/Reports/IncomeAllVehicles' + '?transporter=' + encodeURIComponent(transporter) + '&startDate=' + encodeURIComponent(startDate) + '&endDate=' + encodeURIComponent(endDate);
        var title = "Income All Vehicles: " + transporter; // The title for the tab

        // Call the predefined function
        loadPartialViewIntoTab(url, title, transporter, startDate, endDate);
    });
   
});

function generateReport() {
    // Get form data
    var form = document.getElementById('generateReportForm');
    var formData = new FormData(form);

    // Convert form data to JSON object
    var data = {};
    formData.forEach((value, key) => data[key] = value);

    // Send AJAX request
    fetch('/Reports/GenerateReport', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                return response.text().then(text => { throw new Error(text || 'Network response was not ok'); });
            }
            return response.json();
        })
        .then(result => {
            console.log('Report generated successfully:', result);
            // Handle success response
        })
        .catch(error => {
            console.error('Error generating report:', error);
            // Handle error response
        });
}
function generateReport(event) {
    event.preventDefault(); // Prevent the default form submission

    var form = document.getElementById('generateReportForm');
    var formData = new FormData(form);

    var data = {};
    formData.forEach((value, key) => {
        data[key] = value;
    });

    fetch('/Reports/GenerateReport', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                return response.text().then(text => { throw new Error(text || 'Network response was not ok'); });
            }
            return response.json();
        })
        .then(result => {
            console.log('Report generated successfully:', result);
            // Handle success response
        })
        .catch(error => {
            console.error('Error generating report:', error);
            // Handle error response
        });
}