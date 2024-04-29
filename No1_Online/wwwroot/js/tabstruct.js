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
            loadPartialViewIntoTab(url, pageName);
           
        });
    });
});