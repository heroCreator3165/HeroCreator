using System.Collections;
using System.Collections.Generic;
using Misc;
using UnityEngine;

public class ProjectController : Singleton<ProjectController>
{
    public bool HasProject { get; private set; }

    public void CreateProject()
    {
        HasProject = true;
    }

    public void LoadProject()
    {
        HasProject = true;
    }
}
