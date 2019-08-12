import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {

  private projectData;
  constructor(private service:DataService) { }

  ngOnInit() {
  }

  FetchData() {
    this.service.GetAllProjects().subscribe((result) => {
      this.projectData = result;
    });
  }

}
