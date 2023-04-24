const rows = document.querySelectorAll('.row');
const colors = ['#ff7f7f', '#ffbf7f', '#ffdf7f', '#ffff7f', '#bfff7f'];

const onDragOver = (event) => {
  event.preventDefault();
}

const onDrop = (event) => {
  event.preventDefault();
  const draggedCardId = event.dataTransfer.getData('id');
  const draggedCard = document.getElementById(draggedCardId);
  event.target.appendChild(draggedCard);
}

rows.forEach((row, index) => {
  const label = row.querySelector('.label');
  label.style.backgroundColor = colors[index];
  row.ondragover = onDragOver;
  row.ondrop = onDrop;
})
