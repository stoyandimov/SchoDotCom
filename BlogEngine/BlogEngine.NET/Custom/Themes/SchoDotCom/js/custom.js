$(function () {
    // Tag cloud
    if (TagCanvas == undefined) return;
    try {
        TagCanvas.Start('tagCanvas', 'tags', {
            initial: [-0.1, -0.05],
            textColour: '#fff',
            textFont: 'Segoe UI',
            outlineColour: '#fff',
            outlineMethod: 'none',
            reverse: true,
            depth: 0.8,
            maxSpeed: 0.05
        });
        // more options at http://www.goat1000.com/tagcanvas-options.php
    } catch (e) {
        // something went wrong, hide the canvas container
        document.getElementById('tagCanvasContainer').style.display = 'none';
    }
});

$(function () {
    $("pre.hljs").each(function (i, block) {
        hljs.highlightBlock(block);
    });
});