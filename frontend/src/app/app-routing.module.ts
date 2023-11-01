import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TableStudentComponent } from './Pages/Student/TableStudent/TableStudent.component';
import { EditStudentComponent } from './Pages/Student/edit-student/edit-student.component';

const routes: Routes = [
  { path: 'student-list', component: TableStudentComponent },
  { path: 'edit-student/:id', component: EditStudentComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
