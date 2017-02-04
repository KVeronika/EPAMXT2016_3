$(document).ready(function () {
    var endingDates = $('.endingDate'),
        deadlines = [],
        i,
        timers = $('.timer'),
        daysSpan = [],
        hoursSpan = [],
        minutesSpan = [],
        secondsSpan = [];
    for (i = 0; i < endingDates.length; i++) {
        deadlines.push($(endingDates[i]).text());
    }
    for (i = 0; i < timers.length; i++) {
        daysSpan.push(timers[i].querySelector('.days'));
        hoursSpan.push(timers[i].querySelector('.hours'));
        minutesSpan.push(timers[i].querySelector('.minutes'));
        secondsSpan.push(timers[i].querySelector('.seconds'));
    }
    function getTimeRemaining(endtime) {
        var t,
            seconds,
            minutes,
            hours,
            days;
        t = Date.parse(endtime) - Date.parse(new Date());
        seconds = Math.floor((t / 1000) % 60);
        minutes = Math.floor((t / 1000 / 60) % 60);
        hours = Math.floor((t / (1000 * 60 * 60)) % 24);
        days = Math.floor(t / (1000 * 60 * 60 * 24));
        return {
            'total': t,
            'days': days,
            'hours': hours,
            'minutes': minutes,
            'seconds': seconds
        };
    }
    function initializeClock(timer, endtime, i) {
        var t,
            timeinterval;
        function updateClock() {
            t = getTimeRemaining(endtime);
            daysSpan[i].innerHTML = ('0' + t.days).slice(-2) + 'd. ';
            hoursSpan[i].innerHTML = ('0' + t.hours).slice(-2);
            minutesSpan[i].innerHTML = ('0' + t.minutes).slice(-2);
            secondsSpan[i].innerHTML = ('0' + t.seconds).slice(-2);
            if (t.total <= 0) {
                clearInterval(timeinterval);
            }
        }
        updateClock();
        timeinterval = setInterval(updateClock, 1000);
    }

    for (i = 0; i < deadlines.length; i++) {
        initializeClock(timers[i], deadlines[i], i);
    }
});