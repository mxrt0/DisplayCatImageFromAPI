const container = document.getElementById('cat-container');
    const button = document.getElementById('refresh-btn');

    async function loadCat() {
        container.innerHTML = '<p>Loading...</p>';
        try {
            const response = await fetch('/api/cat/image');
            if (!response.ok) {
                throw new Error('Network response was not OK.');
            }
            const data = await response.json();
            container.innerHTML = `<img src="${data.imageUrl}" alt="An image of a cute cat" />`;      
        }
        catch (error) {
            container.innerHTML = `<p>Failed to load image: ${error.message}</p>`;
            console.error(error);
        }  
    }

    window.onload = loadCat; 