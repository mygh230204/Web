const saveBtn = document.querySelector('.saveAsImage');

saveBtn.addEventListener('click', function() {
  const board = document.getElementById('board');
  
  html2canvas(board).then(function(canvas) {
    const link = document.createElement('a');
    link.href = canvas.toDataURL();
    link.download = 'ranker.png';
    document.body.appendChild(link);
    link.click();
  });
});
