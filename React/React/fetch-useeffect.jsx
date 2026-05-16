// React fetch + useEffect minta
// Adatok lekérése backend API-ból

import { useEffect, useState } from "react";

function ProjectComponent() {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    fetch("http://localhost:8000/api/projects/")
      .then((response) => response.json())
      .then((data) => setProjects(data))
      .catch((error) => console.log("Hiba:", error));
  }, []);

  return (
    <div>
      <h1>Projektek</h1>

      {projects.map((project) => (
        <div key={project.id}>
          <h2>{project.title}</h2>
          <p>{project.description}</p>
        </div>
      ))}
    </div>
  );
}

export default ProjectComponent;