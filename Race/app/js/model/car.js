APP.models.car = function(canvas) {
    var car = {
            x: canvas.width/2 - 50,
            y: canvas.height - 150,
            dx: 180,
            width: 100,
            height: 150,
        },
        ctx = canvas.getContext('2d');

    car.move = function(flag) {
        if(flag) {
            if(car.x + car.dx > canvas.width - car.width) {
                car.x += 0;
            } else {
                car.x += car.dx;
            }
        } else {
            if(car.x - car.dx < 0) {
                car.x -= 0;
            } else {
                car.x -= car.dx;
            }
        }
    }

    car.draw = function() {
        ctx.beginPath();
        ctx.fillStyle = '#0095DD';
        ctx.fillRect(car.x, car.y, car.width, car.height);
        ctx.closePath();
    }

    return car;
};