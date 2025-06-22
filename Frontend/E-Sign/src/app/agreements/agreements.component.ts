import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-agreements',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './agreements.component.html',
  styleUrl: './agreements.component.css'
})
export class AgreementsComponent {
  documents = [
    {
      title: 'Abstract 3D',
      desc: 'Lorem ipsum dolor sit amet...',
      status: 'Signed',
      price: '$45.99',
      date: '20',
      image: 'assets/doc1.png'
    },
    {
      title: 'Landing Page 3D max',
      desc: 'Lorem ipsum dolor sit amet...',
      status: 'Unsigned',
      price: '$45.99',
      date: '20',
      image: 'assets/doc2.png'
    },
    {
      title: 'Landing Page 3D max',
      desc: 'Lorem ipsum dolor sit amet...',
      status: 'Unsigned',
      price: '$45.99',
      date: '20',
      image: 'assets/doc2.png'
    },
    {
      title: 'Landing Page 3D max',
      desc: 'Lorem ipsum dolor sit amet...',
      status: 'Unsigned',
      price: '$45.99',
      date: '20',
      image: 'assets/doc2.png'
    }
    // Add other documents similarly
  ];
  metrics = [
    {
      label: 'Total Documents',
      value: '$198k',
      bgColor: '#E8FFF0',  // light green
      circleColor: '#A4F3C3',
      
    },
    {
      label: 'Signed',
      value: '$2.4k',
      bgColor: '#EAF7FF',  // light blue
      circleColor: '#BFE7FF',
      

    },
    {
      label: 'Unsigned',
      value: '$89k',
      bgColor: '#FFE9F0',  // light pink
      circleColor: '#FFB6C9',
    }
  ];

  getStatusClass(status: string) {
    return status === 'Signed' ? 'bg-succes rounded-2' : 'bg-danger rounded-2';
  }
}
