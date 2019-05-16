function setStartCourseEvents() {
    const startNodeList = document.querySelectorAll('.course-start');
    const startBtnArray = Array.from(startNodeList);
    for (let i = 0; i < startBtnArray.length; i++) {
        startBtnArray[i].addEventListener('click', goStartCourse);
    }
}

function setDetailsBtnEvents() {
    const startNodeList = document.querySelectorAll('.course-detail');
    const startBtnArray = Array.from(startNodeList);
    for (let i = 0; i < startBtnArray.length; i++) {
        startBtnArray[i].addEventListener('click', goCourseDetail);
    }
}

function goStartCourse() {
    const courseId = event.currentTarget.getAttribute('data-course-number');
    event.stopPropagation();
    location.href = location.origin + '/course/participate?courseId=' + courseId;
}

function goCourseDetail() {
    const courseId = event.currentTarget.getAttribute('data-course-number');
    event.stopPropagation();
    location.href = location.origin + '/student/detail?courseId=' + courseId;
}

document.addEventListener("DOMContentLoaded", () => {
    setDetailsBtnEvents();
	setStartCourseEvents();
});





