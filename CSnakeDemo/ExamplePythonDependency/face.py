from typing import Tuple, List, Dict

import dlib
import face_recognition


class face_location:

    def __init__(
        self,
        left_top: int,
        right_top: int,
        left_bottom: int,
        right_bottom: int,
    ):
        self.left_top = left_top
        self.right_top = right_top
        self.left_bottom = left_bottom
        self.right_bottom = right_bottom

def detect_faces(image_path: str) -> List[Dict[str, int]]:
    """基础人脸检测功能，返回字典列表"""
    # 加载图片
    image = face_recognition.load_image_file(image_path)

    # 查找所有人脸位置
    face_locations = face_recognition.face_locations(image)
    face_location_list = []  # ✅ 正确创建空列表

    print(f"在图片中检测到 {len(face_locations)} 张人脸")

    for i in face_locations:
        print(i)
        face_location_list.append({
            "left_top": i[0],
            "right_top": i[1],
            "left_bottom": i[2],
            "right_bottom": i[3]
        })

    return face_location_list  # ✅ 返回列表
