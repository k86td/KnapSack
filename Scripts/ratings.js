$(document).ready(() => {
    InstallRating();
});

function InstallRating() {
    $(".rating").each(function () {
        createRating(
            $(this), $(this).attr("ratingId"),
            parseInt($(this).attr("value")),
            $(this).attr("locked"),
            parseFloat($(this).attr("scale").replace(",", ".")));
    });
    $(".star").mouseover(function () {
        if ($(this).attr("locked") == "true") return false;
        let t_num = $(this).attr("num");
        let parentId = $(this).parent().attr("id");
        overSelect(t_num, parentId);
    })
    $(".star").mouseleave(function () {
        if ($(this).attr("locked") == "true") return false;
        let parentId = $(this).parent().attr("id");
        restoreSelect(parentId);
    })
    $(".star").click(function () {
        if ($(this).attr("locked") == "true") return false;
        let t_num = $(this).attr("num");
        let parentId = $(this).parent().attr("id");
        select(t_num, parentId);
    })
}
function createRating(container, ratingId, value, locked, scale = 2) {
    locked = locked.toLowerCase(locked) == "true";
    container.removeClass("rating");
    container.addClass("ratingControl");
    const svgns = "http://www.w3.org/2000/svg";
    if (!locked)
        locked = ratingId == undefined;
    let maxvalue = 5;
    svg = document.createElementNS(svgns, "svg");
    svg.setAttribute("id", "svg-" + ratingId);
    svg.style["width"] = 70 * scale;
    svg.style["height"] = 12 * scale;
    container.append(svg);

    if (!locked) {
        var input = document.createElement("input");
        input.type = "number";
        input.setAttribute("id", ratingId);
        input.setAttribute("name", ratingId);
        input.setAttribute("value", value);
        input.style["display"] = "none";
        container.append(input);
    }
    for (let i = 1; i <= maxvalue; i++) {
        addStar(svg, i, i <= value, scale, locked);
    }
    restoreSelect("svg-" + ratingId);
}
function addStar(svg, num, on, scale, locked = false) {
    const svgns = "http://www.w3.org/2000/svg";
    let points = [
        [160.2, 76.9],
        [244.4, 88.1],
        [184.3, 148.1],
        [199.7, 231.7],
        [124, 193],
        [49.3, 233.5],
        [62.6, 149.6],
        [1.1, 91],
        [85, 77.8],
        [121.7, 1.1]
    ];
    let basicScale = 1 / 20 * scale;
    let posX = (280 * basicScale) * (num - 1);
    let star = document.createElementNS(svgns, "polygon");
    star.setAttribute("class", "star");
    star.setAttribute("on", on);
    star.setAttribute("num", num);
    star.setAttribute("locked", locked);
    if (on)
        star.setAttribute("fill", "orange");
    else
        star.setAttribute("fill", "lightgray");
    for (p of points) {
        var point = svg.createSVGPoint();
        point.x = p[0] * basicScale + posX;
        point.y = p[1] * basicScale;
        star.points.appendItem(point);
    }
    svg.appendChild(star);
}
function overSelect(num, parentId) {
    $("#" + parentId + " > .star").each(function () {
        let t_num = $(this).attr("num");
        if (t_num <= num)
            $(this).attr("fill", "orange");
        else
            $(this).attr("fill", "gray");
    })
}
function restoreSelect(parentId) {
    let inputId = parentId.split("-")[1];
    $("#" + parentId + " > .star").each(function () {
        let on = $(this).attr("on");
        if (on == "true") {
            $(this).attr("fill", "orange");
            $("#" + inputId).val(parseInt($(this).attr("num")));
        }
        else
            $(this).attr("fill", "gray");
    })
}
function select(num, parentId) {
    $("#" + parentId + " > .star").each(function () {
        let t_num = $(this).attr("num");
        $(this).attr("on", t_num <= num);
        restoreSelect(parentId);
    })
}