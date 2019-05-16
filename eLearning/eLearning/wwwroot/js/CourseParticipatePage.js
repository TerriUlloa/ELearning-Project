function addDetailEvents() {
    const sectionNodeList = document.querySelectorAll('.section-expand');
    const sectionArray = Array.from(sectionNodeList);
    for (let i = 0; i < sectionArray.length; i++) {
        sectionArray[i].addEventListener('click', goExpandSection);
    }
}

function addCheckMarkEvents() {
    const checkMarkNodeList = document.querySelectorAll('.fa-check-circle');
    const checkMarkArray = Array.from(checkMarkNodeList);
    for (let i = 0; i < checkMarkArray.length; i++) {
        checkMarkArray[i].addEventListener('click', goCompleteItem);
    }
}

function addPlayButtonEvents() {
    const playBtnNodeList = document.querySelectorAll('.fa-play-circle');
    const playBtnArray = Array.from(playBtnNodeList);
    for (let i = 0; i < playBtnArray.length; i++) {
        playBtnArray[i].addEventListener('click', goPlayItem);
    }
}
function goExpandSection(event) {
    const sectionIndex = event.currentTarget.getAttribute('data-section-number');
    alert("Click event on expand button " + sectionIndex.toString());
}

function goCompleteItem(event) {
    if (!event.currentTarget.classList.contains('completed')) {
        markItemComplete(event.currentTarget);
    }
        event.stopPropagation();
}

function markItemComplete(itemNode) {
    if (!itemNode.classList.contains('completed')) { itemNode.classList.add('completed'); }
}

function goPlayItem(event) {
	const lineIndex = event.currentTarget.getAttribute('data-line-index');
    alert("Click event on Play button " + lineIndex);
    event.stopPropagation();
}

document.addEventListener("DOMContentLoaded", () => {
    addDetailEvents(); 
    addCheckMarkEvents();
    addPlayButtonEvents();
});