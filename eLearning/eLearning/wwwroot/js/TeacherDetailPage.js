function addDetailEvents() {
    const sectionNodeList = document.querySelectorAll('.sectionInfo');
    const sectionArray = Array.from(sectionNodeList);
    for (let i = 0; i < sectionArray.length; i++) {
        sectionArray[i].addEventListener('click', function () { goExpandSection(i); });
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
    const playBtnNodeList = document.querySelectorAll('.fa-check-circle');
    const playBtnArray = Array.from(playBtnNodeList);
    for (let i = 0; i < playBtnArray.length; i++) {
        playBtnArray[i].addEventListener('click', goPlayItem);
    }
}
function goExpandSection(section) {
    alert("Click event on section " + section.toString());
}

function goCompleteItem(event) {
    if (!event.currentTarget.classList.contains('completed')) {
        markItemComplete(event.currentTarget);
        event.currentTarget.removeEventListener('click', goCompleteItem); 
        event.stopPropagation();
    }
}

function markItemComplete(itemNode) {
    if (!itemNode.classList.contains('completed')) { itemNode.classList.add('completed'); }
}

function goPlayItem(event) {
    event.stopPropagation();
}
document.addEventListener("DOMContentLoaded", () => {
    addDetailEvents();
    addCheckMarkEvents();
    addPlayButtonEvents();
});