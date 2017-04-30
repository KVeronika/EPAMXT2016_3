APP.view = function(canvas, map, car){
    var ctx = canvas.getContext('2d');

    function draw(start, scores) {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        if (!start) {
            // вывод статстики
            ctx.font = 'bold 60px courier';
            ctx.textBaseline = 'top';
            ctx.fillStyle = '#000';
            ctx.fillText('Scores:' + scores.toFixed(2).toString() , canvas.width / 2-200, canvas.height / 2 - 150);
            ctx.font = 'bold 16px courier';
            ctx.textBaseline = 'top';
            ctx.fillStyle = '#000';
            ctx.fillText('Press "Start" button to start new game or continue', canvas.width / 2 - 240, canvas.height / 2 + 25);
        }
        else{
            car.draw();
            map.draw();
        }
    }
    return{
        draw: draw
    }
}