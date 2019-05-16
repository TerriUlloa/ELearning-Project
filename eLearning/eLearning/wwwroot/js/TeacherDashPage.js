function setCourseEditEvents() {
    const courseNodeList = document.querySelectorAll('.course-edit');
    const courseArray = Array.from(courseNodeList);
    for (let i = 0; i < courseArray.length; i++) {
        courseArray[i].addEventListener('click', goEditCourse);
    }
}

function setStudentListEvents() {
    const studentNodeList = document.querySelectorAll('.student-list');
    const studentBtnArray = Array.from(studentNodeList);
    for (let i = 0; i < studentBtnArray.length; i++) {
        studentBtnArray[i].addEventListener('click', goListStudents);
    }
}


function setContentAddEvents() {
    const courseNodeList = document.querySelectorAll('.content-add');
    const courseArray = Array.from(courseNodeList);
    for (let i = 0; i < courseArray.length; i++) {
        courseArray[i].addEventListener('click', goAddContent);
    }
}
function setCourseAddEvent() {
    const addButton = document.querySelector('.course-add');
    addButton.addEventListener('click', goAddCourse);
}

function goCourseDetail(event) {
    const courseId = event.currentTarget.getAttribute('data-course-number');
    event.stopPropagation();
    location.href = location.origin + '/teacher/details?Id=' + courseId;
}

function goListStudents(event) {
    const courseId = event.currentTarget.getAttribute('data-course-number');
    event.stopPropagation();
    location.href = location.origin + '/teacher/progress?Id=' + courseId;
}

function goAddCourse(event) {
    event.stopPropagation();
    location.href = location.origin + '/course/create';
}

function goEditCourse() {
    const courseId = event.currentTarget.getAttribute('data-course-number');
    event.stopPropagation();
    location.href = location.origin + '/course/edit?Id=' + courseId;
}

function goAddContent() {
    const courseId = event.currentTarget.getAttribute('data-course-number');
    event.stopPropagation();
    location.href = location.origin + '/course/details?Id=' + courseId;
}

document.addEventListener('DOMContentLoaded', () => {
    setCourseEditEvents();
    setStudentListEvents();
    setCourseAddEvent();
    setContentAddEvents();
});