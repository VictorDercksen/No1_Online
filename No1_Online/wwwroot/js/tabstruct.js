document.addEventListener('DOMContentLoaded', function () {
    let tabCounter = 0; // Initialize a counter for unique tab IDs

    const offcanvasLinks = document.querySelectorAll('.offcanvas .nav-link');

    offcanvasLinks.forEach(link => {
        link.addEventListener('click', function (event) {
            event.preventDefault();

            const pageName = this.textContent.trim();
            // Append a unique counter value to the pageId
            const uniqueId = ++tabCounter;
            const pageId = `${pageName.toLowerCase().replace(/\s+/g, '-')}-${uniqueId}`;
            const url = this.getAttribute('href'); // The URL to fetch the view content

            // Create a new tab with a close button
            const newTab = document.createElement('li');
            newTab.className = 'nav-item';
            newTab.innerHTML = `
                        <a class="nav-link" id="tab-${pageId}" data-bs-toggle="tab" href="#pane-${pageId}" role="tab">
                            ${pageName} ${uniqueId}
                            <button class="close-tab-btn" data-target="#tab-${pageId}" style="border:none; background:none;">&times;</button>
                        </a>
                    `;
            document.querySelector('#dynamicTabList').appendChild(newTab);

            // Create a new tab pane
            const newPane = document.createElement('div');
            newPane.className = 'tab-pane fade';
            newPane.id = `pane-${pageId}`;
            newPane.role = 'tabpanel';
            fetch(url)
                .then(response => response.text())
                .then(html => {
                    newPane.innerHTML = html;
                    document.querySelector('#dynamicTabContent').appendChild(newPane);
                    new bootstrap.Tab(document.querySelector(`#tab-${pageId}`)).show();
                });

            // Add event listener for the close button
            newTab.querySelector('.close-tab-btn').addEventListener('click', function (event) {
                event.stopPropagation();
                const targetId = this.getAttribute('data-target');
                const targetTab = document.querySelector(targetId);
                const targetPaneId = targetTab.getAttribute('href');
                const targetPane = document.querySelector(targetPaneId);

                // Remove the tab and its content
                targetTab.parentNode.remove();
                targetPane.remove();

                // Activate the first tab if available
                const firstTab = document.querySelector('.nav-tabs .nav-item:first-child .nav-link');
                if (firstTab) {
                    new bootstrap.Tab(firstTab).show();
                }
            });
        });
    });
});