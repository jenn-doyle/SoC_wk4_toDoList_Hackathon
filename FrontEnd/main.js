const mainList = document.querySelector("#main-list");
const inputForm = document.querySelector("#input-form");

const BACKEND_URL = "http://localhost:5000";

async function loadInitialToDos() {
  const res = await fetch(`${BACKEND_URL}/todoitems`);
  const data = await res.json();
  data.forEach(renderToDo);
}


function renderToDo(toDoItem) {
  const { id, title, priority, isComplete } = toDoItem;

  const span = document.createElement("span");
  span.innerText = `${title} - priority: ${priority}`;

  const li = document.createElement("li");
  li.id = `to-do-item-${id}`;
  li.appendChild(createCheckbox(toDoItem));
  li.appendChild(span);
  li.appendChild(createDeleteButton(toDoItem));
  li.appendChild(createEditButton(toDoItem));
    if (isComplete) {
    li.classList.add("completed");
  }
  mainList.appendChild(li);

}

function createCheckbox(toDoItem) {
  const checkBox = document.createElement("input");
  checkBox.type = "checkbox";
  checkBox.addEventListener("change", () => {
    toggleToDoComplete(toDoItem);
  });
  return checkBox;
}

function createDeleteButton(toDoItem) {
  const button = document.createElement("button");
  button.innerText = "DELETE";
  button.addEventListener("click", () => {
    deleteToDo(toDoItem);
  });
  return button;
}

function createEditButton(toDoItem) {
  const editButton = document.createElement("button");
  editButton.innerText = "UPDATE";
  editButton.addEventListener("click", () => {
    editToDo(toDoItem);
  });
  return editButton;
}
 

async function handleAddToDo(event) {
  // stops page reloading by default
  event.preventDefault();
  // get title and priority from form
  const partialTodo = {
    title: event.target[0].value,
    priority: event.target[1].value,
  };
  // sent to database and recieve full item including id
  const completeTodo = await sendToDo("/todoitems", "POST", partialTodo);
  event.target.reset();
  renderToDo(completeTodo);
}

async function sendToDo(path, method, body = "") {
  const res = await fetch(`${BACKEND_URL}${path}`, {
    method,
    headers: {
      "content-type": "application/json",
    },
    body: JSON.stringify(body),
  });
  const data = await res.json();
  return data;
}

async function toggleToDoComplete(toDoItem) {
  const li = document.querySelector(`#to-do-item-${toDoItem.id}`);
  await sendToDo(`/todoitems/${toDoItem.id}`, "PUT", {
    ...toDoItem,
    isComplete: !li.classList.contains("completed"),
  });
  li.classList.toggle("completed");
}

async function editToDo(toDoItem) {
  const res = await fetch(`${BACKEND_URL}/todoitems/${toDoItem.id}`, {
    method: "UPDATE",
  });
  if (res.ok) {
    document.querySelector(`#to-do-item-${toDoItem.id}`).replaceWith();
  }
}

async function deleteToDo(toDoItem) {
  const res = await fetch(`${BACKEND_URL}/todoitems/${toDoItem.id}`, {
    method: "DELETE",
  });
  if (res.ok) {
    document.querySelector(`#to-do-item-${toDoItem.id}`).remove();
  }
}

const deleteCompleteButton = document.querySelector(".delete-completed");

async function deleteAllToDoItems() {
  const res = await fetch(`${BACKEND_URL}/todoitems/`, {
    method: "DELETE",
  });
  if (res.ok) {
    location.reload();
  }
}


deleteCompleteButton.addEventListener("click", deleteAllToDoItems);

inputForm.addEventListener("submit", handleAddToDo);

loadInitialToDos();



