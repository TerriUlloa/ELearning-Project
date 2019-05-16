function setLoginButtonEvent() {
    const buttonNode = document.querySelector('.nav-login');
    buttonNode.addEventListener('click', goLogin);
}

function setRegisterButtonEvent() {
    const buttonNode = document.querySelector('.nav-register');
    buttonNode.addEventListener('click', goRegister);
}

function setCourseRedirectEvent() {
    const courseNodeList = document.querySelectorAll('.courseList > div');
    const divArray = Array.from(courseNodeList);
    for (let i = 0; i < divArray.length; i++) {
        divArray[i].addEventListener('click', goLogin);
    }
}
function goLogin() {
    location.href = location.origin + '/user/login';
}

function goRegister() {
    location.href = location.origin + '/user/register';
}

document.addEventListener("DOMContentLoaded", () => {
//    addNavButtons();
    setLoginButtonEvent();
    setRegisterButtonEvent();
    setCourseRedirectEvent();
});