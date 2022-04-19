let cnv = document.getElementById("cnv");
let ctx = cnv.getContext("2d");

ctx.arc(12, 10, 10, 0, 2 * Math.PI);

// ctx.arc(788, 10, 10, 0, 2 * Math.PI);

// ctx.arc(785, 688, 10, 0, 2 * Math.PI);

// ctx.arc(10, 688, 10, 0, 2 * Math.PI);

ctx.moveTo(10, 10);
ctx.lineTo(790, 690);

ctx.moveTo(790, 10);
ctx.lineTo(10, 690);

ctx.moveTo(400, 10);
ctx.lineTo(400, 690);

ctx.moveTo(10, 350);
ctx.lineTo(790, 350);

ctx.moveTo(10, 10);
ctx.lineTo(10, 690);

ctx.moveTo(10, 10);
ctx.lineTo(790, 10);

ctx.moveTo(790, 10);
ctx.lineTo(790, 690);

ctx.moveTo(10, 690);
ctx.lineTo(790, 690);

//ctx.arc(0, 0, 20, 0, 2 * Math.PI);

ctx.stroke();
