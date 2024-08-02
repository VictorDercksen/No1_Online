//document.body.addEventListener('click', function (event) {
//    // Check if the upload button was clicked
//    if (event.target && event.target.id === 'uploadButton') {
//        var fileInput = document.getElementById('fileInput');
//        if (fileInput.files.length > 0) {
//            var file = fileInput.files[0];
//            var formData = new FormData();
//            formData.append('csvFile', file);

//            // Perform the fetch call to upload the file
//            fetch('/Csv/Upload', {
//                method: 'POST',
//                body: formData
//            })
//                .then(response => {
//                    if (!response.ok) {
//                        console.error('Server responded with status:', response.status);
//                        throw new Error('Network response was not OK');
//                    }
//                    return response.text();  // Changed to .text() if you are not sure about the response type
//                })
//                .then(data => {
//                    console.log('Server Response:', data);
//                    var title = "Upload Results";
//                    loadPartialModViewIntoTab(data, title);  // Update this if necessary based on actual response type
//                })
//                .catch(error => {
//                    console.error('Error uploading file:', error);
//                    alert('Failed to upload file.');
//                });

//        } else {
//            alert('Please select a file to upload.');
//        }
//    }
//});

function loadPartialModViewIntoTab(htmlContent, title) {
    var tabId = 'tab-' + Math.random().toString(36).substr(2, 9); // Generate a unique ID for the tab
    var tabHtml = '<li class="nav-item"><a class="nav-link" id="' + tabId + '" data-bs-toggle="tab" href="#' + tabId + '-content">' + title + ' <button class="close-tab-btn" data-target="#' + tabId + '" style="border:none; background:none;">&times;</button></a></li>';
    var paneHtml = '<div class="tab-pane fade" id="' + tabId + '-content">' + htmlContent + '</div>';

    document.querySelector('#dynamicTabList').insertAdjacentHTML('beforeend', tabHtml);
    document.querySelector('#dynamicTabContent').insertAdjacentHTML('beforeend', paneHtml);

    new bootstrap.Tab(document.querySelector('#' + tabId)).show(); // Activate the new tab

    // Adding event listener to the close button
    document.querySelector('#' + tabId + ' .close-tab-btn').addEventListener('click', function (event) {
        event.preventDefault();  // Prevent default action
        event.stopPropagation(); // Stop the event from bubbling up

        var targetId = this.getAttribute('data-target');
        var targetTab = document.querySelector('a[href="' + targetId + '-content"]');
        var targetPane = document.querySelector(targetId + '-content');

        if (targetTab && targetPane) {
            targetTab.parentNode.remove(); // Remove the tab
            targetPane.remove(); // Remove the tab content

            // Optionally, activate the first available tab after closing one
            var firstTab = document.querySelector('.nav-tabs .nav-item:first-child .nav-link');
            if (firstTab) {
                new bootstrap.Tab(firstTab).show();
            }
        }
    });
}

