function getWindowSize() {
    return [window.innerWidth, window.innerHeight];
}

function drawTheThing(x, y, width, height, color) {
    const canvas = document.getElementById('gameCanvas');
    const ctx = canvas.getContext('2d');
    
    // Set canvas size to match window
    canvas.width = window.innerWidth;
    canvas.height = window.innerHeight;
    
    // Clear shit
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    
    // paint the shit
    ctx.fillStyle = color;
    ctx.fillRect(x, y, width, height);
    
    ctx.fillStyle = 'black';
    ctx.font = '20px Arial';
    ctx.fillText('WASM', x + width/2 - 30, y + height/2 + 5);
}

// Export functions for WASM
window.gameInterop = {
    getWindowSize,
    drawTheThing
};