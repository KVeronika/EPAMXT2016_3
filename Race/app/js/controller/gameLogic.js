'use strict';
var canvas = document.getElementById('mainCanvas'),
    startBtn = document.getElementById('startBtn'),
    stopBtn = document.getElementById('stopBtn'),
    scoreLabel = document.getElementById('scoreLabel'),

    car = APP.models.car(canvas),
    //для карты препятствий
    map = APP.models.map(canvas),
    updateInterval = 0,
    start = false,
    lose = false,
    scores = 0,
    view = APP.view(canvas, map, car);

startBtn.addEventListener('click', function() {
    updateInterval = 20;
    start = true;
    startNewGame();
});

stopBtn.addEventListener('click', function() {
    updateInterval = 0;
    start = false;
});

function play() {
    if(lose) {
        start = false;
        lose = false;
        updateInterval = 0;
        view.draw(start, scores);
    }
    else if(updateInterval !== 0) {
        map.incrementTimeOfGame(updateInterval);
        view.draw(start, scores);
        lose = map.update(car);
        scores +=0.01;
        scoreLabel.innerText = scores.toFixed(2).toString();
    }
    else if (!start) {
        view.draw(start, scores);
    }
}

function startNewGame() {
    //заново инициализируем карту и все нужные параметры
    map.reset();
    scores = 0;
}

window.onkeydown = function (event) {
    updateCar(event);
};

function updateCar(event) {
    //движение машинки вправо
    if (event.keyCode === 39) {
        car.move(true);
    }
    //движение машинки влево
    else if(event.keyCode === 37) {
        car.move(false);
    }
}

setInterval(play, 20);