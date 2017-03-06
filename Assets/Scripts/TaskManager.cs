using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TaskManager : MonoBehaviour {

    private readonly List<Task> taskList = new List<Task>();

    // Use this for initialization
    void Start () {
    
    }
    

    public void AddTask(Task task)
    {
	Debug.Assert(task != null);
	// Only add tasks that aren't already attached.
	Debug.Assert(!task.IsAttached);
	taskList.Add(task);
	task.SetStatus(Task.TaskStatus.Pending);
    }

    void Update () {
	
	for (int i = taskList.Count - 1; i >= 0; --i)
	{
	    Task task = taskList[i];
	    // Initialize any tasks that have just been added        
	    if (task.IsPending)
	    {
		task.SetStatus(Task.TaskStatus.Working);
	    }

	    if (task.IsFinished)
	    {
		HandleCompletion(task, i);
	    }
	    else
	    {
		// update the task and clear it if it's done
		task.Update();
		if (task.IsFinished)
		{
		    HandleCompletion(task, i);
		}
	    }
	} // end for  
    } // end update

    private void HandleCompletion(Task task, int taskIndex)
    {
	if (task.NextTask != null && task.IsSuccessful)
	{
	    AddTask(task.NextTask);
	}
	
	taskList.RemoveAt(taskIndex);
	task.SetStatus(Task.TaskStatus.Detached);
	// How to garbage collect?
    }
} 
