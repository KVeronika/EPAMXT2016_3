APP.models.map = function(canvas) {
    var pieceOfMap = [],
        map = [],
        n = 0,
        m = 3,
        blockWidth = 170,
        blockHeight = 175,
        dyForBlock = 5,
        timeOfGame = 0,
        updateInterval = 0,
        ctx = canvas.getContext('2d');

    function init() {
        var i,
            j,
            n = 4,
            m = 3;

        // заполнение карты 0
        for(i = 0; i < n; i++) {
            pieceOfMap[i] = [];
            for(j = 0; j < m; j++) {
                pieceOfMap[i].push(0);
            }
        }
        //заполнение препятствий в рандомные позиции через строку(чтобы избежать тупиков)
        for(i = 0; i < n; i++) {
            if(i % 2 === 0) {
                j = randomInteger(0,2);
                pieceOfMap[i][j] = {
                    flag: 1,
                    startX: j * blockWidth,
                    startY: 0 - i * blockHeight,
                };
            }
            map.push(pieceOfMap[i]);
        }
    }

    function randomInteger(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function draw() {
        var i,
            j;

        ctx.fillStyle = '#000';
        if(timeOfGame === updateInterval || timeOfGame % 3000 === 0) {
            init();
            n += 4;
        }
        for(i = 0; i < n; i++) {
            for(j = 0; j < m; j++) {
                if(map[i][j].flag === 1) {
                    ctx.fillRect(map[i][j].startX, map[i][j].startY, blockWidth, blockHeight);
                }
            }
        }
    }

    function update(car) {
        var i,
            j;

        for(i = 0; i < n; i++) {
            for(j = 0; j < m; j++) {
                if(map[i][j].flag === 1) {
                    if(collision(car, map[i][j])) {
                        return true;
                    }
                    map[i][j].startY += dyForBlock;
                }
            }
        }
        return false;
    }

    function collision(car, block) {
        return block.startX + blockWidth > car.x && block.startX < car.x + car.width
                && block.startY + blockHeight > car.y && block.startY < car.y + car.height;
    }

    function reset() {
        pieceOfMap = [];
        map = [];
        n = 0;
        m = 3;
        timeOfGame = 0;
    }

    function incrementTimeOfGame(interval) {
        timeOfGame += interval;
    }

    return {
        map: map,
        init: init,
        draw: draw,
        update: update,
        reset: reset,
        incrementTimeOfGame: incrementTimeOfGame
    };
};