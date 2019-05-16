function addCancelEvent() {
    const cancelButton = document.querySelector('.edit-cancel');
    cancelButton.addEventListener('click', goCancelEdit);
}

function goCancelEdit(event) {
	event.stopPropagation();
	location.href = location.origin + '/teacher/dashboard';
}

document.addEventListener("DOMContentLoaded", () => {
    addCancelEvent();
});