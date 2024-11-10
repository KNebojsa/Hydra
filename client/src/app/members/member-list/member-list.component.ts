import { Component, inject, OnInit } from '@angular/core';
import { MemberService } from '../../_services/member.service';
import { CommonModule } from '@angular/common';
import { Member } from '../../_models/member';
import { MemberCardComponent } from "../member-card/member-card.component";

@Component({
  selector: 'app-member-list',
  standalone: true,
  imports: [CommonModule, MemberCardComponent],
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.css',
})

export class MemberListComponent implements OnInit {
  private memberService = inject(MemberService);
  members: Member[] = [];

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers() {
    this.memberService.getMembers().subscribe({
      next: (members) => this.members = members,
      error: (err) => console.error('Error fetching users', err)
    });
  }

  // getMainPhotoUrl(user: User): string {
  //   const mainPhoto = user.photos.find(photo => photo.isMain);
  //   return mainPhoto ? mainPhoto.url : 'default-photo-url.jpg';
  // }
}