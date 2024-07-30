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

let tabCounter = 1;

function toggleMetadata(report) {
    var metadataElement = document.getElementById('metadata-' + report);
    $(metadataElement).slideToggle(); // Use jQuery's slideToggle for animation
}

function deleteReport(report) {
    // Implement the delete report logic here
    console.log("Delete report: " + report);
}

function addTab(tabId, paneId, tabTitle, url, startDate, endDate, transporter, page) {
    startDate = startDate || "defaultStartDate"; // Provide a default value if startDate is null or empty
    endDate = endDate || "defaultEndDate";
    tabCounter++;
    var newTabId = `${tabId}-${tabCounter}`;
    var newTabPaneId = `${paneId}-content-${tabCounter}`;
    let fullUrl;
    switch (page) {
        case "AllIncomeTransporter":
            var _transporter = encodeURIComponent(transporter);
            fullUrl = `${url}/${startDate}/${endDate}/${_transporter}`;
            break;
        case "CompanySearch":
            var company = encodeURIComponent(transporter);
            fullUrl = `${url}/${company}`;
            break;
        case "LoadingScheduleSearch":
            fullUrl = url;
            break;
        case "LoadingSchedule":
            fullUrl = url;
            break;
    }


    // Add a new tab with a close button
    $("#dynamicTabList").append(
        '<li class="nav-item">' +
        '<a class="nav-link" id="' + newTabId + '" data-bs-toggle="tab" href="#' + newTabPaneId + '">' + tabTitle + ' ' +
        '<button type="button" class="close-tab-btn" aria-label="Close" style="border:none; background:none;" onclick="closeTab(\'' + newTabId + '\', \'' + newTabPaneId + '\')">&times;</button>' +
        '</a>' +
        '</li>'
    );

    // Add a new tab pane
    $("#dynamicTabContent").append(
        `<div class="tab-pane fade" id="${newTabPaneId}" role="tabpanel" aria-labelledby="${newTabId}">
                                            <div id="spinner-wrapper" class="d-flex">
                                                <div class="spinner"></div>
                                            </div>
                                        </div>`
    );

    // Activate the new tab
    $("#" + newTabId).tab('show');
    $("#" + newTabPaneId).load(fullUrl);

    // Load the content into the new tab pane
    // $("#" + paneId).load(fullUrl, function (response, status, xhr) {
    //     if (status == "error") {
    //         var msg = "Sorry but there was an error: ";
    //         $("#" + paneId).html(msg + xhr.status + " " + xhr.statusText);
    //     }
    // });
}





















