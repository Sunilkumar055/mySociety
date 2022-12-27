import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServiceService } from 'app/service.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router, private ServiceService:ServiceService) { }
    
  userList: any=[];
  username: string;
  password: string;
  errorMsg: string;
  ngOnInit(): void {
    this.loaddate();
  }

   loaddate(){       
       this.ServiceService.getData().subscribe({
       next(value) {
        this.userList = value;
       },error(err) {
         alert(err);
       },complete() {
        alert(JSON.stringify(this.userList));
       }
      })          
   }  
  login(){
    var val={
        username: this.userList.username,
        password:this.userList.password
    }    
    this.ServiceService.authUser(val).subscribe(res=>{
      this.router.navigate(['admin']);
    },error=>{      
      this.errorMsg = "Invalid username or password";
    });    
  }  
}
