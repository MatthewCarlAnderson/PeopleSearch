export class Person {
  public id: number;
  public firstName: string;
  public lastName: string;
  public address: string;
  public age: number;
  public interests: string;
  simage: any[];

  get image() {
    return 'data:image/jpeg;base64, ' + this.simage;
  }

  constructor(data?: any) {
    Object.assign(this, assignData(data));
  }
}

function assignData(data) {
  return {
    id: data.id,
    firstName: data.firstName,
    lastName: data.lastName,
    address: data.address,
    age: data.age,
    interests: data.interests,
    simage: data.image
  }
}
