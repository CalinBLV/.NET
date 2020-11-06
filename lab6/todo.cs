public class Todo {
    private int Id;
    private string Description;
    private DateTime Created;
    private bool IsDone;

    public Todo()
    {
        this.IsDone = false;
    }

    public Todo(int Id, string Description, DateTime Created)
    {
        this.Id = Id; this.Description = Description; this.Created = Created; this.IsDone = false;
    }
}

class Program{

    public List<Todo> getAllTodos(){
        List<Todo> returnList = new List<Todo>();
        using(var db = new Database())
        {
            returnList = db.Todos.ToList();
        }
        return returnList;
    }

    public List<Todo> getActiveTodos() {
        List<Todo> returnList = new List<Todo>();
        using(var db = new Database())
        {
            returnList = db.Todos.Where(x => x.IsDone == false).ToList();
        }
        return returnList;
    }

    public List<Todo> getDoneTodos() {
        List<Todo> returnList = new List<Todo>();
        using(var db = new Database())
        {
            returnList = db.Todos.Where(x => x.IsDone == true).ToList();
        }
        return returnList;
    }

    public Todo getTodoById(int id) {
        Todo todo = null;
        using(var db = new Database())
        {
            todo = db.Todos.FirstOrDefault(x => x.Id == id);
        }
        return todo;
    }

    public void UpdateTodo(Todo todo) {
        using (var db = new Database())
        {
            var todoToUpdate = db.Todos.FirstOrDefault(x => x.Id == todo.Id);
            if (todoToUpdate != null)
            {
                todoToUpdate.Description = todo.Description;
                todoToUpdate.Created = todo.Created;
                todoToUpdate.IsDone = todo.IsDone;
                db.SaveChanges();
            }
        }
    }

    public void deleteTodoById(int id){
        using (var db = new Database())
        {
            var todo = db.Todos.FirstOrDefault(x => x.Id == id);
            if(todo != null)
            {
                db.Todos.Remove(todo);
                db.SaveChanges();
            }
        }
    }

    public static void main(string[] args)
    {

    }
}