export interface BaseResponse<T> {
  IsSuccess: any,
  Data: T,
  Message: any
}


export interface GenericResponse<T> {
  statusCode: any
  data: T
  message: string
}

export interface Baseentity<T>{
  totalRecords: number,
  items: T
}
