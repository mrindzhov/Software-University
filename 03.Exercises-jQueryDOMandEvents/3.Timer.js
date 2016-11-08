function timer() {
    let ticking = false;
    let time, intervalID;
    let startBtn = $('#start-timer');
    let stopBtn = $('#stop-timer');
    let hours = $('#hours').val();
    let minutes = $('#minutes').val();
    let seconds = $('#seconds').val();
    
    startBtn.on('click', function() {
        //time = -1;
        //step();
        if(!ticking) {
            intervalID = setInterval(step, 1000);
            ticking = true;
        }
    });

    stopBtn.on('click', function() {
        clearInterval(intervalID);
        ticking = false;
    });
    function step() {

        seconds++;
        seconds %= 60;
        $("#seconds").text(("0" + Math.trunc(seconds % 60)).slice(-2));
        if (seconds == 0) {
            minutes++;
            minutes %= 60;
            $("#minutes").text(("0" + Math.trunc(minutes % 60)).slice(-2));
            if (minutes == 0) {
                hours++;
                hours %= 100;
                $("#hours").text(("0" + Math.trunc(hours % 100)).slice(-2));
            }
        }
    }
}