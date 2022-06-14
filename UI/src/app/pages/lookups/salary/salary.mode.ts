export interface salary{
    id:number;
    grade:string;
    position:string;
    growth:number;
    pension:number;
    tax:number;
    allowance:number;
    net:number;
}

export interface createSalary{
    grade:string;
    position:string;
    growth:number;
    allowance:number;
}

export interface updateSalary{
    grade:string;
    position:string;
    growth:number;
    allowance:number;
}