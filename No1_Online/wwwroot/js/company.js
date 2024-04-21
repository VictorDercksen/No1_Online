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
                var title = "Company Search Result";
                loadPartialViewIntoTab(url, title);
            }
            event.preventDefault();
        }
    });
});

document.addEventListener('DOMContentLoaded', function () {
    document.addEventListener('click', function (event) {
        if (event.target.matches('#LoadsearchButton')) {
            var searchValue = document.querySelector('#LoadsearchBox').value;
            if (searchValue) {
                var url = '/LoadingSchedule/SearchLoadingSchedule?searchBox=' + encodeURIComponent(searchValue);
                var title = "Company Search Result";
                loadPartialViewIntoTab(url, title);
            }
            event.preventDefault();
        }
    });
});

function loadPartialViewIntoTab(url, title) {
    var tabId = 'tab-' + Math.random().toString(36).substr(2, 9); // Generate a unique ID for the tab
    console.log(url);

    // Create the new tab with a close button
    var tabHtml = '<li class="nav-item"><a class="nav-link" id="' + tabId + '" data-bs-toggle="tab" href="#' + tabId + '-content">' + title + ' <button class="close-tab-btn" data-target="#' + tabId + '" style="border:none; background:none;">&times;</button></a></li>';
    document.querySelector('#dynamicTabList').insertAdjacentHTML('beforeend', tabHtml);

    // Create the content pane for the new tab
    var paneHtml = '<div class="tab-pane fade" id="' + tabId + '-content"></div>';
    document.querySelector('#dynamicTabContent').insertAdjacentHTML('beforeend', paneHtml);

    // Load the content into the pane
    fetch(url)
        .then(response => {
            if (!response.ok) {
                return response.text().then(text => { throw new Error(text || 'Network response was not ok'); });
            }
            return response.text();
        })
        .then(html => {
            document.querySelector('#' + tabId + '-content').innerHTML = html;
            new bootstrap.Tab(document.querySelector('#' + tabId)).show();
        })
        .catch(error => {
            console.error('Error fetching search results:', error);
        });

    // Add event listener for the close button
    document.querySelector('#' + tabId + ' .close-tab-btn').addEventListener('click', function (event) {
        event.stopPropagation();
        var targetId = this.getAttribute('data-target');
        var targetTab = document.querySelector(targetId);
        var targetPaneId = targetTab.getAttribute('href');
        var targetPane = document.querySelector(targetPaneId);

        // Remove the tab and its content
        targetTab.parentNode.remove();
        targetPane.remove();

        // Activate the first tab if available
        var firstTab = document.querySelector('.nav-tabs .nav-item:first-child .nav-link');
        if (firstTab) {
            new bootstrap.Tab(firstTab).show();
        }
    });
}





