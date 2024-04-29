document.addEventListener('DOMContentLoaded', function () {
    const searchBox = document.getElementById('searchBox');
   

    function createAutocomplete(input, url) {
        let suggestions = document.createElement('div');
        suggestions.classList.add('autocomplete-suggestions');
        document.body.appendChild(suggestions);

        input.addEventListener('input', function () {
            const rect = input.getBoundingClientRect();
            suggestions.style.width = rect.width + 'px'; // Match the input width
            suggestions.style.left = rect.left + window.scrollX + 'px';
            suggestions.style.top = rect.bottom + window.scrollY + 'px';

            if (!input.value) {
                suggestions.style.display = 'none';
                return; // Hide suggestions if input is empty
            }

            fetch(url + '?term=' + encodeURIComponent(input.value))
                .then(response => response.json())
                .then(data => {
                    suggestions.innerHTML = '';
                    if (data.length) {
                        data.forEach(item => {
                            let div = document.createElement('div');
                            div.textContent = item;
                            div.classList.add('autocomplete-suggestion');
                            div.addEventListener('click', function () {
                                input.value = this.textContent;
                                suggestions.innerHTML = '';
                                suggestions.style.display = 'none';
                            });
                            suggestions.appendChild(div);
                        });
                        suggestions.style.display = 'block';
                        suggestions.style.opacity = 1;
                    } else {
                        suggestions.style.display = 'none';
                    }
                })
                .catch(error => console.error('Error fetching data:', error));
        });

        // Hide suggestions when clicking outside
        document.addEventListener('click', function (event) {
            if (!input.contains(event.target) && !suggestions.contains(event.target)) {
                suggestions.style.opacity = 0;
                setTimeout(() => {
                    suggestions.innerHTML = '';
                    suggestions.style.display = 'none';
                }, 200); // Allow time for opacity transition before hiding
            }
        });
    }



    createAutocomplete(searchBox, '/Company/AutoSearchCompany');
    
});