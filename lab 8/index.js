'use strict';

class Point2D{

    constructor(x, y){
        this.x = x;
        this.y = y;
    }

    /**
     * 
     * @param {Point2D} p2D 
     */
    move(p2D){
        this.x += p2D.x;
        this.y += p2D.y;
    }
}

/**
 * 
 * @returns {array} array of Point2D's
 */
function getData(){
    let point1X = document.getElementById('point1x');
    let point2X = document.getElementById('point2x');
    let point3X = document.getElementById('point3x');

    let point1Y = document.getElementById('point1y');
    let point2Y = document.getElementById('point2y');
    let point3Y = document.getElementById('point3y');

    let arr = [];
    arr.push(new Point2D(parseInt(point1X.value), parseInt(point1Y.value)));
    arr.push(new Point2D(parseInt(point2X.value), parseInt(point2Y.value)));
    arr.push(new Point2D(parseInt(point3X.value), parseInt(point3Y.value)));

    return arr;
}

/**
 * Рисует треугольник
 * 
 * @param {*} ctx 
 * @param {Point2D} p1 
 * @param {Point2D} p2 
 * @param {Point2D} p3 
 * @param {*} color 
 */
function drawTriangle(ctx, p1, p2, p3, color = 'rgb(0, 250, 250)'){
    ctx.strokeStyle = color;
    ctx.beginPath();

    ctx.moveTo(p1.x, p1.y);
    ctx.lineTo(p2.x, p2.y);
    ctx.lineTo(p3.x, p3.y);
    ctx.lineTo(p1.x, p1.y);

    // ctx.moveTo(p1.x + 1, p1.y);
    // ctx.lineTo(p2.x + 1, p2.y);
    // ctx.lineTo(p3.x + 1, p3.y);
    // ctx.lineTo(p1.x + 1, p1.y);

    // ctx.moveTo(p1.x + 2, p1.y);
    // ctx.lineTo(p2.x + 2, p2.y);
    // ctx.lineTo(p3.x + 2, p3.y);
    // ctx.lineTo(p1.x + 2, p1.y);
    ctx.stroke();
}

/**
 * Рисует квадрат
 * 
 * @param {*} ctx 
 * @param {Point2D} p1 
 * @param {Point2D} p2 
 * @param {Point2D} p3 
 * @param {Point2D} p4 
 * @param {String} color 
 */
function drawSquare(ctx, p1, p2, p3, p4, color = 'rgb(0, 250, 250)'){
    ctx.strokeStyle = color;
    ctx.beginPath();

    ctx.moveTo(p1.x, p1.y);
    ctx.lineTo(p2.x, p2.y);
    ctx.lineTo(p3.x, p3.y);
    ctx.lineTo(p4.x, p4.y);
    ctx.lineTo(p1.x, p1.y);
    ctx.stroke();
}

/**
 * 
 * @param {*} ctx 
 * @param {Point2D} p1 
 * @param {Point2D} p2 
 * @param {Point2D} p3 
 */
function paintOver(ctx, p1, p2, p3, color = 'rgb(0, 250, 250)'){

    // k = (p3.y - p1.y) / (p3.x - p1.x)
    let k1 = (p2.x - p1.x) / (p2.y - p1.y);
    let k2 = (p3.x - p1.x) / (p3.y - p1.y);

    ctx.strokeStyle = color;
    ctx.beginPath();

    let x1 = 0;
    let x2 = 0;
    for (let y = p1.y; y < p2.y; y++){
        x1 = p1.x + (y - p1.y) * k1;
        x2 = p1.x + (y - p1.y) * k2;
        ctx.moveTo(x1, y);
        ctx.lineTo(x2, y);
    }
    ctx.stroke();

    let k3 = (p2.x - p3.x) / (p2.y - p3.y);
    let x = x2;
    ctx.beginPath();
    for (let y = p2.y; y < p3.y; y++){
        x1 = x + (y - p2.y) * k2;
        x2 = p2.x + (y - p2.y) * k3;
        ctx.moveTo(x1, y);
        ctx.lineTo(x2, y);
    }
    ctx.stroke();
}

/**
 * Закрасить пиксель
 * 
 * @param {*} ctx 
 * @param {Point2D} p 
 */
function setPixel(ctx, p, color = 'rgb(0, 250, 250)'){

    ctx.fillStyle = color;
    ctx.fillRect( p.x, p.y, 1, 1 );
}

/**
 * Проверяет равен ли цвет пикселя color
 * 
 * @param {*} ctx 
 * @param {Point2D} p 
 * @param {Array} color 
 */
function checkPixelColor(ctx, p, color){
    let imageData = ctx.getImageData(p.x, p.y, 1, 1).data;
    let pixelColor = 'rgb(' + imageData[0] + ', ' + imageData[1] + ', ' + imageData[2] + ')';
    
    if (Array.isArray(color)){
        let res = false;
        color.forEach(element => {
            if (element == pixelColor) { 
                res = true;  
            }
        });
        return res;
    }
    else{

        if (color == pixelColor){
            return true;
        }
        else{
            return false;
        }
    }
}

/**
 * Получить цвет пикселя
 * 
 * @param {*} ctx 
 * @param {Point2D} p 
 * @returns {string} color
 */
function getColorOfPixel(ctx, p){
    let imageData = ctx.getImageData(p.x, p.y, 1, 1).data;
    let pixelColor = 'rgb(' + imageData[0] + ', ' + imageData[1] + ', ' + imageData[2] + ', ' + imageData[3] + ')';
    return pixelColor;
}

class Stack{

    constructor(){
        this.stack = new Set();
    }

    /**
     * 
     * @param {Point2D} p 
     */
    push(p){
        let s = 'x:' + p.x + 'y:' + p.y;
        this.stack.add(s);
    }

    /**
     * 
     * @returns {Point2D} первая точка из стека
     */
    pop_first(){
        let point = '';
        for (let item of this.stack) {
            point = item;
            break;
        }
        this.stack.delete(point);

        let x = point.indexOf('x:') + 2;
        let y = point.indexOf('y:');
        let end = point.length;
        let first = parseInt(point.slice(x, y));
        let second = parseInt(point.slice(y + 2, end));
        return new Point2D(first, second);
    }

    /**
     * 
     * @returns {Point2D} последняя точка из стека
     */
     pop(){
        let point = '';
        for (let item of this.stack) {
            point = item;
        }
        this.stack.delete(point);

        let x = point.indexOf('x:') + 2;
        let y = point.indexOf('y:');
        let end = point.length;
        let first = parseInt(point.slice(x, y));
        let second = parseInt(point.slice(y + 2, end));
        return new Point2D(first, second);
    }

    size(){
        return this.stack.size;
    }
}

/**
 * Закрашивает весь цвет color цветом paintColor
 * @param {*} ctx 
 * @param {Point2D} p 
 * @param {Array} paintColor
 */
 function zatravka4Color(ctx, p, paintColor, color){
    let stack = new Stack();
    
    let pixel;
    let point = null;
    let count = 0;
    stack.push(p);
    while((stack.size() != 0) && (count <= 10000)){
        pixel = stack.pop();
        console.log(pixel);
        if (checkPixelColor(ctx, pixel, color)){
            
            setPixel(ctx, pixel, paintColor[0]);
            
            point = new Point2D(pixel.x + 1, pixel.y);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++;
            }
            
            point = new Point2D(pixel.x - 1, pixel.y);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++;
            }

            point = new Point2D(pixel.x, pixel.y + 1);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++
            }

            point = new Point2D(pixel.x, pixel.y - 1);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++;
            }
           
        }
    }
}

/**
 * Закрашивает весь цвет color цветом paintColor
 * @param {*} ctx 
 * @param {Point2D} p 
 * @param {Array} paintColor
 */
 function zatravka8Color(ctx, p, paintColor, color){
    let stack = new Stack();
    
    let pixel;
    let point = null;
    let count = 0;
    stack.push(p);
    while((stack.size() != 0) && (count <= 50000)){
        pixel = stack.pop();
         
        if (checkPixelColor(ctx, pixel, color)){
            
            setPixel(ctx, pixel, paintColor[0]);
            
            point = new Point2D(pixel.x + 1, pixel.y);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++;
            }
            
            point = new Point2D(pixel.x - 1, pixel.y);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++;
            }

            point = new Point2D(pixel.x, pixel.y + 1);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++
            }

            point = new Point2D(pixel.x, pixel.y - 1);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++;
            }

            point = new Point2D(pixel.x + 1, pixel.y - 1);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++;
            }
            
            point = new Point2D(pixel.x + 1, pixel.y + 1);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++;
            }

            point = new Point2D(pixel.x - 1, pixel.y + 1);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++
            }

            point = new Point2D(pixel.x - 1, pixel.y - 1);
            if (checkPixelColor(ctx, point, color)) {
                stack.push(point);
                count++;
            }
        }
    }
}

const CANVAS_COLOR = 'rgb(255, 255, 255)';
const DRAW_COLOR = 'rgb(0, 250, 250)';

const canvas = document.querySelector('.canvas');
canvas.width = 1000;
canvas.height = 1000;
const ctx = canvas.getContext('2d');
let colors = [];

const btnStart = document.querySelector('.btn');
btnStart.addEventListener('click', () => {
    let arr = getData();

    ctx.fillStyle = CANVAS_COLOR;
    ctx.fillRect(0, 0, canvas.width, canvas.height); // clear canvas

    colors = [];

    drawTriangle(ctx, ...arr);
    colors.push(getColorOfPixel(ctx, arr[0]));
    colors.push('rgb(0, 250, 250)');

    // drawSquare(
    //     ctx, 
    //     new Point2D(1, 1),
    //     new Point2D(100, 1),
    //     new Point2D(100, 100),
    //     new Point2D(1, 100)
    // );
    // colors.push(getColorOfPixel(ctx, new Point2D(1, 1)));
    // colors.push(getColorOfPixel(ctx, new Point2D(50, 100)));
    // colors.push('rgb(0, 250, 250)');
    
});

const btnPaint = document.querySelector('.btn-paint');
btnPaint.addEventListener('click', (e) => {
    let arr = getData();
    paintOver(ctx, ...arr);

    //zatravka4Color(ctx, new Point2D(50, 40), colors, "rgb(255, 255, 255)");
    //zatravka8Color(ctx, new Point2D(50, 40), colors, "rgb(255, 255, 255)");
	// setPixel(ctx, new Point2D(50, 40));
});

window.addEventListener('click', function (e) {
    if (e.ctrlKey){
        colors = [];
        console.log(e.pageX);
        console.log(e.pageY);

        colors.push(DRAW_COLOR);
        setPixel(ctx, new Point2D(e.pageX, e.pageY), "rgb(0, 0, 0)");
        zatravka4Color(ctx, new Point2D(e.pageX, e.pageY), colors, "rgb(0, 0, 0)");
        setPixel(ctx, new Point2D(e.pageX, e.pageY), "rgb(255, 0, 0)");
    }
});

let mouse = { x:0, y:0};
let draw = false;
 
canvas.addEventListener("mousedown", function(e){
     
    mouse.x = e.pageX - this.offsetLeft;
    mouse.y = e.pageY - this.offsetTop;
    draw = true;
    ctx.strokeStyle = DRAW_COLOR;
    ctx.lineWidth = 2;
    ctx.beginPath();
    ctx.moveTo(mouse.x, mouse.y);
});
canvas.addEventListener("mousemove", function(e){
     
    if(draw==true){
     
        mouse.x = e.pageX - this.offsetLeft;
        mouse.y = e.pageY - this.offsetTop;
        ctx.lineTo(mouse.x, mouse.y);
        ctx.stroke();
    }
});
canvas.addEventListener("mouseup", function(e){
     
    mouse.x = e.pageX - this.offsetLeft;
    mouse.y = e.pageY - this.offsetTop;
    ctx.lineTo(mouse.x, mouse.y);
    ctx.stroke();
    ctx.closePath();
    draw = false;
});


