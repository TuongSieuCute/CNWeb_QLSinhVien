import { AddStudentComponent } from './Pages/Student/Add-Student/Add-Student.component';
import { TableStudentComponent } from './Pages/Student/TableStudent/TableStudent.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {NgxPaginationModule} from 'ngx-pagination'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {Routes, RouterModule} from '@angular/router'
import { SidebarComponent } from './Pages/Sidebar/Sidebar.component';
import { FormsModule } from '@angular/forms';
import { EditStudentComponent } from './Pages/Student/edit-student/edit-student.component';

const appRoutes: Routes = [
  {path: 'table', component: TableStudentComponent},
  {path: 'add', component: AddStudentComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    TableStudentComponent,
    AddStudentComponent,
    EditStudentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    NgxPaginationModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
