///model for todo entry
export interface todoEntry {
  id: number;
  subject: string;
  startDate: Date;
  dueDate: Date;
  status: string;
  priority: string;
  percentageCompleted: number;
}
