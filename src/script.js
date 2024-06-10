let content = document.getElementById("pageContent");
loadPage(0);

function loadPage(i) {
    content.innerHTML = pages[i];
}