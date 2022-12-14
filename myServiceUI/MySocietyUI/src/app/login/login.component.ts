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
    //this.loadDate();
  }

  // loadDate(){       
  //     this.ServiceService.getData().subscribe(data=>{
  //       this.userList = data;            
  //     })     
  // }  
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
