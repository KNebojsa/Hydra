import { Component, inject, OnInit } from '@angular/core';
import { MemberService } from '../../_services/member.service';
import { MemberCardComponent } from '../member-card/member-card.component';

@Component({
  selector: 'app-member-list',
  standalone: true,
  imports: [MemberCardComponent],
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.css',
})
export class MemberListComponent implements OnInit {
  memberService = inject(MemberService);

  ngOnInit(): void {
    if (this.memberService.members().length === 0) {
      this.loadMembers();
    }
  }

  loadMembers() {
    this.memberService.getMembers();
  }

  // getMainPhotoUrl(user: User): string {
  //   const mainPhoto = user.photos.find(photo => photo.isMain);
  //   return mainPhoto ? mainPhoto.url : 'default-photo-url.jpg';
  // }
}
