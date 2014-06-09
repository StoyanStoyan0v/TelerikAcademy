window.onload= function () {
    var stage = new Kinetic.Stage({
        container: 'container',
        width: 1300,
        height: 700
    });

    var layer = new Kinetic.Layer(),
		imageObj = new Image(),
		direction = "right";

    imageObj.onload = function () {
        var mario = new Kinetic.Sprite({
            x: 520,
            y: 515,
            scaleX: 2,
            scaleY:2,
            image: imageObj,
            animation: 'idle',
            animations: {
                idle: [
                  10, 5, 30, 60,
                ],
                move: [
                 40, 5, 20, 60,
                 60, 5, 20, 60,
                 80, 5, 20, 60,
                ]
            },
            frameRate: 7,
            frameIndex: 0
        });

        layer.add(mario);
        stage.add(layer);

        mario.start();

        var frameCount = 0;

        mario.on('frameIndexChange', function (evt) {

            if (mario.animation() === 'move' && ++frameCount > 7) {
                mario.animation('idle');
                
                frameCount = 0;
            }
        });

        window.addEventListener('keydown', onKeyDown);
        window.addEventListener('keyup', onKeyUp);

        function moveLeft() {
            if (direction === 'left') {
                mario.setX(mario.attrs.x -= 10);
                mario.scaleX(-2);
                mario.attrs.animation = "move";
            } else {
                mario.setX(mario.attrs.x += 50);
                mario.scaleX(-2);
                direction = 'left';
                mario.attrs.animation = "move";
            }

        }

        function moveRight() {
            if (direction === 'right') {
                mario.setX(mario.attrs.x += 10);
                mario.scaleX(2);
                mario.attrs.animation = "move";
            } else {
                mario.setX(mario.attrs.x -= 50);
                mario.scaleX(2);
                direction = 'right';
                mario.attrs.animation = "move";
            }
        }
 
        function onKeyDown(evt) {
            switch (evt.keyCode) {
                case 37:
                    if (mario.attrs.x > 10) {
                        moveLeft();
                    } else {
                        stop(0);
                    }
                    break;
                case 39:
                    if (mario.attrs.x < document.getElementsByTagName('canvas')[0].width - 30) {
                        moveRight();
                    } else {
                        stop(document.getElementsByTagName('canvas')[0].width - 30);
                    }
                    break;
            }
        }
        function onKeyUp() {
            frameCount = 7;
        }

    };

    imageObj.src = 'images/7747.png';

    var paper = new Raphael(0, 0, 1300, 700);

    paper.image("images/overworld_bg.png", 0, 0, 1300, 700);
}
