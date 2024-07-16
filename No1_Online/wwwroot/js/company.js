// Ensure only one checkbox is checked at a time
document.addEventListener('change', function(event) {
    var checkbox = event.target;
    if (checkbox.type === 'checkbox' && checkbox.checked) {
        document.querySelectorAll('input[type="checkbox"]').forEach(function(otherCheckbox) {
            if (otherCheckbox !== checkbox) {
                otherCheckbox.checked = false;
            }
        });
    }
});
document.addEventListener('DOMContentLoaded', function () {
    document.addEventListener('click', function (event) {
        if (event.target.matches('#searchButton')) {
            var searchValue = document.querySelector('#searchBox').value;
            if (searchValue) {
                var url = '/Company/SearchCompany?searchBox=' + encodeURIComponent(searchValue);
                var title = searchValue;
                loadPartialViewIntoTab(url, title);
            }
            event.preventDefault();
        }
    });

    document.addEventListener('click', function (event) {
        if (event.target.matches('#LoadsearchButton')) {
            var searchValue = document.querySelector('#LoadsearchBox').value;
            if (searchValue) {
                var url = '/LoadingSchedule/SearchLoadingSchedule?searchBox=' + encodeURIComponent(searchValue);
                var title ='Load: ' +  searchValue;
                loadPartialViewIntoTab(url, title);
            }
            event.preventDefault();
        }
    });


});



function toggleMetadata(report) {
    var metadataElement = document.getElementById('metadata-' + report);
    $(metadataElement).slideToggle(); // Use jQuery's slideToggle for animation
}

function deleteReport(report) {
    // Implement the delete report logic here
    console.log("Delete report: " + report);
}





















