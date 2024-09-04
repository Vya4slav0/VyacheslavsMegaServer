const textarea = document.getElementsByName("reportText")[0];
const currentLength = document.querySelector('.current');
const counter = document.querySelector('.counter');
const maxlength = 1000;
const minlength = 5;

function onInput(event) {
    const input = event.target.value.trim();
    if (input.length >= maxlength || input.length < minlength) {
        counter.style.color = "#FF5555";
        counter.style.textShadow = "#3F1515";
    }
    else {
        counter.style.color = "whitesmoke";
        counter.style.textShadow = "2px 2px #3f3f3f";
    }
    input.value = input.substr(0, maxlength);
    currentLength.textContent = input.length;
}

textarea.addEventListener('input', onInput);