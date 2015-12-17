function evaluationExpression_fx(str, x) {
    var y;
    y=eval(treatmenter(str));
    return y * 1.0;
}


function evaluationExpression_ft(str, t) {
    var y;
    y=eval(treatmenter(str));
    return y * 1.0;
}

function evaluationExpression_polar(str, a) {
    var y;
	
	treatmenter(str);
    y=eval(treatmenter(str));
    return y * 1.0;
}

function treatmenter(str)
{
	str = str.replace(/arccos/g, "Math.ac os");
	str = str.replace(/arcsin/g, "Math.as in");
	str = str.replace(/sin/g, "Math.s in");
	str = str.replace(/arctg/g, "Math.a tan");
	str = str.replace(/arctg/g, "Math.ata n");
	str = str.replace(/e/g, "Math.e xp");
	str = str.replace(/sqrt/g, "Math.sq rt");
	str = str.replace(/sqr/g, "Math.sq r");
	str = str.replace(/ln/g, "Math.lo g");
	str = str.replace(/cos/g, "Math.co s");
	str = str.replace(/csc/g, "1/Math.co s");
	str = str.replace(/sc/g, "1/Math.s in");
	str = str.replace(/ctg/g, "1/Math.ta n");
	str = str.replace(/tg/g, "Math.ta n");
	str = str.replace(/pow/g, "Math.po w");
	str = str.replace(/abs/g, "Math.ab s");

	str = str.replace(/ /g, "");
	return str;
}
