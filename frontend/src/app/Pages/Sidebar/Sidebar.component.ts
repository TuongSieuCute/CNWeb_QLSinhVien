import { Component, OnInit } from '@angular/core';
import { sidebarData } from './Sidebar-data';
import { QuanLyService } from 'src/app/Services/QuanLy.service';

@Component({
  selector: 'app-Sidebar',
  templateUrl: './Sidebar.component.html',
  styleUrls: ['./Sidebar.component.css']
})
export class SidebarComponent implements OnInit{
  constructor(public QuanLyService: QuanLyService) {}

  get isSidebarOpen() {
    return this.QuanLyService.isSidebarOpen;
  }

  toggle() {
    this.QuanLyService.toggleSidebar();
  }

  sideData = sidebarData; 
  
  ngOnInit(): void {

  }
}
