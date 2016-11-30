/**
 * Created by Veronika on 11/29/2016.
 */
(function () {
    var pages = ['/Task9.4/Index.html', '/Task9.4/Page2.html', '/Task9.4/Page3.html'],
        timer = 5,
        toNextPageBtn = document.getElementById('goToNextPage'),
        restartTimerBtn = document.getElementById('restartTimer');
    if(toNextPageBtn !== null){
        toNextPageBtn.addEventListener('click', goToNextPage);
    }
    restartTimerBtn.addEventListener('click', restartTimer);

    setTimeout(function run() {
        timer--;
        document.getElementById('timer').innerText = timer;
        if(timer === 0){
            goToNextPage();
        }
        setTimeout(run, 1000);
    }, 1000);

    function goToNextPage() {
        var i;
        for(i = 0; i < pages.length; i++){
            if(window.location.pathname === pages[pages.length - 1]){
                finalPageProcessing();
                return;
            }
            if(pages[i] === window.location.pathname){
                window.location.replace(pages[++i]);
                return;
            }
        }
    }
    function finalPageProcessing() {
        var isAgain = confirm('You want to see it again?');
        if(isAgain){
            window.location.replace(pages[0]);
        }
        else{
            window.close();
        }
    }
    function restartTimer() {
        timer = 5;
    }
})();