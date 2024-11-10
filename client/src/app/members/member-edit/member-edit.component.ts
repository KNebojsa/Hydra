import { Component, inject, OnInit } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { Member } from '../../_models/member';
import { MemberService } from '../../_services/member.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TabsModule } from 'ngx-bootstrap/tabs';

@Component({
  selector: 'app-member-edit',
  standalone: true,
  imports: [TabsModule, FormsModule],
  templateUrl: './member-edit.component.html',
  styleUrl: './member-edit.component.css',
})
export class MemberEditComponent implements OnInit {
updateMember() {
throw new Error('Method not implemented.');
}
  member?: Member;
  private accountService = inject(AccountService);
  private memberService = inject(MemberService);

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember() {
    const user = this.accountService.currentUser();
    if (!user) return;
    this.memberService.getMember(user.username).subscribe({
      next: member => (this.member = member),
    });
  }
}
